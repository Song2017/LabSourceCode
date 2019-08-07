// Create your own Event Tracker system:
//
// 1. create an `EventTracker` object
//    • it should accept a name when constructed
// 2. extend the `EventTracker` prototype with:
//    • an `on` method
//    • a `notify` method
//    • a `trigger` method
//


var EventTracker = function (name) {
    this.name = name;
    this._events = [];
    this._notify = []
};
//事件，返回方法
EventTracker.prototype.on = function (event, callback) {
    if (this._events[event] == undefined) {
        this._events[event] = [];
    }
    this._events[event].push(callback);
};
//参数：EventTracker对象，事件
EventTracker.prototype.notify = function (otherObj, event) {
    if (this._notify[event] == undefined) {
        this._notify[event] = [];
    }
    this._notify[event].push(otherObj);
};
//参数：事件，方法返回的信息
EventTracker.prototype.trigger = function (event, data) {
    var listCallBacks = this._events[event] || 0;
    var listNotifys = this._notify[event] || 0;
    var i;

    for (i = 0; i < listCallBacks.length; i++) {
        listCallBacks[i].call(this, data);
        console.log("call back "+ this.name);
        console.log("call back[]  "+ listCallBacks[i]);
    }

    for (i = 0; i < listNotifys.length; i++) {
        listNotifys[i].trigger(event, data);
        console.log("call back2 "+ event);
        console.log("call back[]2  "+ listNotifys[i].name);
        console.log("call back2 "+ data);
    }
};

// EXAMPLE:
//创建两个事件
var nephewParties = new EventTracker('nephews ');
var richard = new EventTracker('Richard');
//事件触发后调用的方法
function purchase(item) {
    console.log('purchasing ' + item);
}
function celebrate() {
    console.log(this.name + ' says birthday parties are awesome!');
}
//事件mainEvent注册调用方法
nephewParties.on('mainEvent', purchase);
richard.on('mainEvent', celebrate); 
//事件对象添加事件
nephewParties.notify(richard, 'mainEvent');
//触发事件，执行每个注册对象的方法并返回信息
nephewParties.trigger('mainEvent', 'ice cream');
