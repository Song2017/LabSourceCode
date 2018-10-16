var request = require('request');
var crypto = require('crypto');

var getCharacterInfo = function (name, callback) {
    var timestamp = new Date().toISOString();
    var publicKey = process.env.MARVEL_PUB_KEY + 'publicKey';
    var privateKey = process.env.MARVEL_PRI_KEY + 'privateKey';
    var hash = crypto.createHash('md5').update(timestamp + publicKey + privateKey).digest('hex');

    var options = {
        url: 'http://gateway.marvel.com/v1/public/characters',
        qs: {
            ts: timestamp,
            name: name,
            apikey: publicKey,
            hash: hash
        }
    };

    // get msg from mavel
    request.get(options, function (error, msg, body) {
        if (error) {
            console.log("Error getting character: " + error);
            callback(error);
            return;
        }
        if (msg.statusCode != 200) {
            console.log("Got a bad status code: " + msg.statusCode);
            callback(msg.statusCode)
            return;
        }

        var infoObj = JSON.parse(body);

        if (infoObj.data.count === 0) {
            callback(null, null);
            return;
        }

        //use first character
        var character = infoObj.data.results[0];
        callback(null, character);
    });
}

exports.getCharacterInfo = getCharacterInfo;