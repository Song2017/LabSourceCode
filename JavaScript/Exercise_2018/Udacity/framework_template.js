
// EXAMPLE:
// in the example below `*(` is my default opening delimiter and `)*` is the default closing delimiter
// var string = "Hi, my name is Richard. And I *( emotion )* this *( thing )*!";
// var logResult = template( string );
// logResult( 'love', 'ice cream', 2 ); // logs the message "Hi, my name is Richard. And I love this ice cream!", twice
//
//
// var string = "Is <<! thing !>> healthy to <<! action !>>?";
// var logResult = template( string, {open: '<<!', close: '!>>'} );
// logResult( 'ice cream', 'consume', 7 ); // logs the message "Is ice cream healthy to consume?", seven times

var template = function(str, delims) {
  // Fill this in
  var dftdelims = {
    open : '*(',
    close : ')*',
  };

  var warpInQuotes = function (text) {
    return "'" + text + "'";
  }

  for (var key in delims) {
    if (delims.hasOwnProperty(key)) {
      if (delims[key] != undefined)
        dftdelims[key] = delims[key];
    }
  }

  var templateString = [];
  var i = 1;
  var closingDelimLoc = 0;
  var funcArgs = [];
  var theVar, remaining;

  var segments = str.split(dftdelims.open);
  var indexSegments = segments.length;

  templateString.push(warpInQuotes(segments[0]));

  while (i < indexSegments) {
    closingDelimLoc = segments[i].indexOf(dftdelims.close);
    theVar = segments[i].slice(0, closingDelimLoc);
    funcArgs.push(theVar);
    templateString.push(theVar);

    remaining = segments[i].slice(closingDelimLoc + dftdelims.close.length);
    templateString.push(warpInQuotes(remaining));

    i++;
  }

  templateString = 'while(times--){ console.log(' + templateString.join('+') + ')}';

  return new Function( funcArgs.join(','), 'times', templateString);
  /*ƒ anonymous( emotion , thing ,times
    ) {
    while(times--){ console.log('Hi, my name is Richard. And I '+ emotion +' this '+ thing +'!')}
    }
    */
}


//addEventListener 方法是 DOM API 的极为重要的组成部分。该方法使你能够监听浏览器的事件系统
document.addEventListener( 'keydown', function ( eventObject ) {
  if (eventObject.keyCode == 27) {
     alert('esc has been input');
  }
});


// Example	Markup
// Checkbox	<input type="checkbox" id="checkbox"/><label for="checkbox">Checkbox</label>
<input type="button" onclick="simulateClick();" value="Simulate click"/>
<input type="button" onclick="addHandler();" value="Add a click handler that calls preventDefault"/>
<input type="button" onclick="removeHandler();" value="Remove the click handler that calls preventDefault"/>
// Scripts used
function preventDef(event) {
  event.preventDefault();
}

function addHandler() {
  document.getElementById("checkbox").addEventListener("click", 
    preventDef, false);
}

function removeHandler() {
  document.getElementById("checkbox").removeEventListener("click",
    preventDef, false);
}

function simulateClick() {
  var evt = document.createEvent("MouseEvents");
  evt.initMouseEvent("click", true, true, window,
    0, 0, 0, 0, 0, false, false, false, false, 0, null);
  var cb = document.getElementById("checkbox"); 
  var canceled = !cb.dispatchEvent(evt);
  if(canceled) {
    // A handler called preventDefault
    alert("canceled");
  } else {
    // None of the handlers called preventDefault
    alert("not canceled");
  }
}
