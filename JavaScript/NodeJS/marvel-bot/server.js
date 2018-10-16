var restify = require('restify');
var builder = require('botbuilder');
var marvel = require('./marvel-helper.js');

// Setup restify server
var server = restify.createServer();
server.listen(process.env.port || process.env.PORT || 3978, function() {
    console.log("%s listening to %s", server.name, server.url);
});

// Create bot
var connector = new builder.ChatConnector({
    appId: process.env.MICROSOFT_APP_ID,
    appPassword: process.env.MICROSOFT_APP_PASSWORD
});
var bot = new builder.UniversalBot(connector);

// Handle Bot Framework messages
server.post('/api/messages', connector.listen());

// Define root dialog
bot.dialog('/', function (session) {
    var msg = session.message.text.toLowerCase();
    if(msg.indexOf('hello') >= 0 || msg.indexOf('hi') >= 0) {
        var userName = session.message.user.name;
        session.send(`Hello ${userName}! I am the Simple Marvel Bot. You can ask me the details of Marvel superheroes. For example, you can say, 'I want to know about a hero'`);
    }
    else {
        session.beginDialog('/getinfo');
    }
});

// Get info dialog
bot.dialog('/getinfo', [
    function (session) {
        builder.Prompts.text(session, "Which character do you want to know about?");
    },
    function (session, results) {
        var name = results.response;

        marvel.getCharacterInfo(name, function(error, character) {
            if (error) {
                session.endDialog("Sorry, I couldn't get info about that character");
                return;
            }
            if(!character) {
                session.endDialog("Sorry, I couldn't find that character");
                return;
            }

            // Create a hero card
            var cardTitle = character.name;
            var cardText = character.description;
            var imageUrl = character.thumbnail.path + '.' + character.thumbnail.extension;
            var cardImage = builder.CardImage.create(session, imageUrl);
            var actionUrl = character.urls[0].url;
            if(actionUrl.substr(0, 5) !== "https") {
                actionUrl = actionUrl.slice(0, 4) + "s" + actionUrl.slice(4);
            }
            var cardAction = builder.CardAction.openUrl(session, actionUrl, "More details");
            var heroCard = new builder.HeroCard(session)
                .title(cardTitle)
                .text(cardText)
                .images([cardImage])
                .buttons([cardAction]);
            
            // Create message with hero card attachment
            var msg = new builder.Message(session)
                .attachments([heroCard]);

            session.endDialog(msg);
        });
    }
]);