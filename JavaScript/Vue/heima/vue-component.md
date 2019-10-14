组件
原因: 为了拆分vue实例的代码量, 让我们以不同的组件来划分不同的功能模块.
组件化和模块化的不同:
    模块化: 从代码逻辑的角度进行划分, 方便代码功能开发, 保持职能单一原则
    组件化: 从UI界面的角度进行划分, 前端组件化, 方便UI组件的重用
注意: 
+ 自定义组件以标签的形式使用, 驼峰命名时, 标签名以-分隔
+ 组件元素应该只有一个根元素
+ 模板可以放到外部组件template元素中
+ 组件与实例的交互: ref='myh3', 事件注册机制


创建:
create: Vue.extend 创建, 2: Vue.component 注册 
    var com1 = Vue.extend({
        template: '<h3>this is h3 tag </h3>',//指定组件要展示的html结构
    });
    Vue.component('myCom1', com1);
    Vue.component('mycom1', Vue.extend({
        template: '<h3>this is h3 tag </h3>',//指定组件要展示的html结构
    });); 
组件切换
<h3>component vue提供的组件展示标签, 是一个占位符, :is指定要展示的组件的名称</h3>
<a href="" @click.prevent='comName="login"'>login</a>
<a href="" @click.prevent='comName="counter"'>counter</a>
<component :is="comName"></component>

生命周期
beforeCreate, 实例初始化完成, 但是只有初始值
this is msg
created, 实例的属性和方法已经创建完成, data, methods可操作了
  {{msg}} <br>   <input type="button" value="update msg" @click="update">
beforeMount, 模板在内存中已经渲染完成, 但是没有挂载到DOM
  this is msg <br> <input type="button" value="update msg">
mounted, 模板已经挂载到DOM,实例创建阶段的最后一个事件, 接下来进入运行阶段界面数据:
  this is msg <br> <input type="button" value="update msg">, msg: msg was updated
beforeUpdate, 这时界面还没有被更新, 数据被更新了
  界面数据: msg was updated <br> <input type="button" value="update msg">, msg: msg was updated
updated, 这时界面被更新, 数据被更新