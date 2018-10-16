var restify = require('restify');
var builder = require('botbuilder');
var marvel = require('./marvel-helper.js');

// Setup Restify Server
var server = restify.createServer();
server.listen(3978, function () {
    console.log('%s listening to %s', server.name, server.url);
});

// create bot
var connector = new builder.ChatConnector({
    appId: null,
    appPassword: null
});
var bot = new builder.UniversalBot(connector);

//handle bot framework message
server.post('/api/messages', connector.listen());

//define root dialog
bot.dialog('/', function (session) {
    var msg = session.message.text.toLowerCase();
    if (msg.indexOf('hello') >= 0 || msg.indexOf('hi') >= 0) {
        var userName = session.message.user.name;
        session.send(`Hello ${userName}, I am marvel Bot. You can ask me the details of Marvel superheroes. 
        For example, you can say, 'I want to know about a hero'`);
    }
    else {
        session.beginDialog('/getinfo');
    }
});

bot.dialog('/getinfo', [
    function (session) {
        builder.Prompts.text(session, 'Which character do you want to know about?');
    },
    function (session, results) {
        var name = results.response;

        marvel.getCharacterInfo(name, function (error, character) {
            if (error) {
                session.endDialog("Sorry, I couldn't get info about the character");
                return;
            }
            if (!character) {
                session.endDialog("Sorry, I couldn't find that character");
                return;
            }

            //hero card
            var cardTitle = character.name;
            var cardText = character.description;
            var imageUrl = character.thumbnail.path + '.' + character.thumbnail.extension;
            var cardImage = builder.cardImage.create(session, imageUrl);
            var actionUrl = character.urls[0].url;
            if (actionUrl.substr(0, 5) !== 'https') {
                actionUrl = actionUrl.slice(0, 4) + 's' + actionUrl.slice(4);
            }
            var cardAction = builder.cardAction.openUrl(session,actionUrl,"More Details");
            var heroCard = new builder.HeroCard(session)
            .title(cardTitle)
            .text(cardText)
            .images([cardImage])
            .buttons([cardAction]);

            var msg = new builder.Message(session)
            .attachments([heroCard]);

        });
    }
]);