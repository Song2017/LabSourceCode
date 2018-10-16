## Angular Home
[angular.cn](https://angular.cn/)
[angular.io](https://angular.io/)
[angular-in-memory-web-api](https://www.npmjs.com/package/angular-in-memory-web-api)
## Creat
你使用 CLI 创建了第二个组件 HeroesComponent。
    `ng generate component heroes`
你把 HeroesComponent 添加到了壳组件 AppComponent 中，以便显示它。
  `app.component.html <app-heros></app-heros>`
你使用 UppercasePipe 来格式化英雄的名字。
  ` heros.component.html <h2>{{hero.name | uppercase}} Details</h2>`
你用 ngModel 指令实现了双向数据绑定。
  `<input [(ngModel)]="hero.name" placeholder="name">`
你知道了 AppModule。
  添加元数据的地方，Angular 需要知道如何把应用程序的各个部分组合到一起，以及该应用需要哪些其它文件和库。 这些信息被称为元数据（metadata）
你把 FormsModule 导入了 AppModule，以便 Angular 能识别并应用 ngModel 指令。
 ` app.module.ts import { FormsModule } from '@angular/forms'; // <-- NgModel lives here
  imports: [
    BrowserModule,
    FormsModule
  ],`
你知道了把组件声明到 AppModule 是很重要的，并认识到 CLI 会自动帮你声明它。
  `@NgModule({ declarations: [AppComponent,HerosComponent],。。。})`
 

## Display
英雄指南应用在一个主从视图中显示了英雄列表。
 ` click事件  html <li *ngFor="let hero of heroes" (click)="onSelect(hero)">
            ts onSelect(hero: Hero): void {this.selectedHero = hero;}`
用户可以选择一个英雄，并查看该英雄的详情。
  `<input [(ngModel)]="selectedHero.name" placeholder="name">`
你使用 *ngFor 显示了一个列表。
  `<li *ngFor="let hero of heroes" [class.selected]='hero === selectHero' (click)="onSelect(hero)">`
你使用 *ngIf 来根据条件包含或排除了一段 HTML。
  `<div *ngIf='selectHero'></div>`
你可以用 class 绑定来切换 CSS 的样式类。
  `[class.selected]='hero === selectHero' `


## Master/Detail
你创建了一个独立的、可复用的 HeroDetailComponent 组件。
  `ng generate component hero-detail`
你用属性绑定语法来让父组件 HeroesComponent 可以控制子组件 `HeroDetailComponent。
  import { Hero } from '../hero';
  @Input() hero: Hero;`
你用 @Input 装饰器来让 hero 属性可以在外部的 HeroesComponent 中绑定
 ` <app-hero-detail [hero]="selectedHero"></app-hero-detail>
  import { Input } from '@angular/core';
`

## Service
你把数据访问逻辑重构到了 HeroService 类中。
  组件不应该直接获取或保存数据， 它们应该聚焦于展示数据，而把数据访问的职责委托给某个服务
你在根模块 AppModule 中提供了 HeroService 服务，以便在别处可以注入它。
  `ng generate service hero --module=app //not insert automatically
  import { HeroService } from './hero.service';
  @NgModule({providers: [HeroService]})`
你使用 Angular 依赖注入机制把它注入到了组件中。
  `heroes.component.ts: import { HeroService } from '../hero.service';
  constructor(private heroService: HeroService) { } `
你给 HeroService 中获取数据的方法提供了一个异步的函数签名。
  服务是在多个“互相不知道”的类之间共享信息的好办法
  回调函数，可以返回 Promise（承诺），也可以返回 Observable（可观察对象）
你发现了 Observable 以及 RxJS 库。
 ` import { Observable, of } from 'rxjs';`
你使用 RxJS 的 of() 方法返回了一个模拟英雄数据的可观察对象 `(Observable<Hero[]>)。
  getHeroes(): Observable<Hero[]> {
    this.messageService.add('HeroService: fetched heroes');
    return of(HEROES);
  }`
在组件的 ngOnInit 生命周期钩子中调用 HeroService 方法，而不是构造函数中。
  让构造函数保持简单，只做初始化操作，比如把构造函数的参数赋值给属性。 构造函数不应该做任何事
你创建了一个 MessageService，以便在类之间实现松耦合通讯。
  `ng generate service message --module=app`
  HeroService 连同注入到它的服务 MessageService 一起，注入到了组件中。
  `hero.service.ts: import { MessageService } from './message.service';
  constructor(private messageService: MessageService) { }
  export class HeroesComponent implements OnInit {
    constructor(private heroService: HeroService) {}
    ngOnInit() {this.getHeroes();}
    getHeroes(): void {this.heroService.getHeroes().subscribe(heroes => this.heroes = heroes);}
  }`


## Router
添加了 Angular 路由器在各个不同组件之间导航。
  `ng generate module app-routing --flat --module=app`
你使用一些 `<a> `链接和一个` <router-outlet>` 把 AppComponent 转换成了一个导航用的壳组件。
  `app.component.html
  <nav>
      <a routerLink="/dashboard">DashBoard</a>
      <a routerLink="/heroes">Heroes</a>
  </nav>
  <router-outlet></router-outlet>`
你在 AppRoutingModule 中配置了路由器。
 ` const routes: Routes = [
    { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
    { path: 'heroes', component: HeroesComponent },
    { path: 'dashboard', component: DashboardComponent },
    { path: 'detail/:id', component: HeroDetailComponent },
  ];
  @NgModule({
    imports: [RouterModule.forRoot(routes)]...
  })`
你定义了一些简单路由、一个重定向路由和一个参数化路由。
  `{ path: 'heroes', component: HeroesComponent },
  { path: '', redirectTo: '/dashboard', pathMatch: 'full' },
  { path: 'detail/:id', component: HeroDetailComponent },`
你在 `<a>` 元素中使用了 routerLink 指令。
  `dashboard.component.html&heroes.component.html 
  <a routerLink="/detail/{{hero.id}}">`
你把一个紧耦合的主从视图重构成了带路由的详情视图。
  `hero-detail.component.ts
  export class HeroDetailComponent implements OnInit {
    @Input() hero: Hero;
    constructor(
      private route: ActivatedRoute,
      private heroService: HeroService,
      private location: Location) { }
    ngOnInit() {
      this.getHero();
    }
    getHero(): void {
      const id = +this.route.snapshot.paramMap.get('id');
      this.heroService.getHero(id)
        .subscribe(hero => this.hero = hero);
    }
  }`
你使用路由链接参数来导航到所选英雄的详情视图。
  `getHero(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.heroService.getHero(id)
      .subscribe(hero => this.hero = hero);
  }`
在多个组件之间共享了 HeroService 服务。
 ` hero.service.ts//读取数据的服务
  use: dashboard.component.ts&heroes.component.ts&hero-detail.component.ts`


## HTTP
你添加了在应用程序中使用 HTTP 的必备依赖。
`hero.service.ts
import { HttpClient, HttpHeaders } from '@angular/common/http';
constructor(
  private http: HttpClient,
  private messageService: MessageService) { }`

你重构了 HeroService，以通过 web API 来加载英雄数据。
```getHeroes(): Observable<Hero[]> {
  return this.http.get<Hero[]>(this.heroesUrl) //return of(HEROES);
    .pipe(
      tap(heroes => this.log(`fetch heroes`)),
      catchError(this.handleError('getHeroes', [])
      ));
}```
你扩展了 HeroService 来支持 post()、put() 和 delete() 方法。
```hero.service.ts 
  updateHero(hero: Hero): Observable<any> {
    return this.http.put(this.heroesUrl, hero, httpOptions).pipe(
      tap(() => this.log(`update hero id = ${hero.id}`)),
      catchError(this.handleError<any>('updateHero'))
    );
  }
  addHero(hero: Hero): Observable<Hero> {
    return this.http.post<Hero>(this.heroesUrl, hero, httpOptions).pipe(
      tap(() => this.log(`add hero w/ id=${hero.id}`)),
      catchError(this.handleError<Hero>('addHero'))
    );
  }
  deleteHero(hero: Hero | number): Observable<Hero> {
    const id = typeof hero === 'number' ? hero : hero.id;
    const url = `${this.heroesUrl}/${id}`;
    return this.http.delete<Hero>(url, httpOptions).pipe(
      tap(() => this.log(`delete hero id=${id}`)),
      catchError(this.handleError<Hero>('deleteHero'))
    );
  }```

你修改了组件，以允许用户添加、编辑和删除英雄。
`heroes.component.html
  <label>Hero Name:
    <input #heroName> 
  </label>
  <button (click)="add(heroName.value);heroName.value=''">add</button>
heroes.component.ts 
  add(name:string):void{
    name=name.trim();
    if(!name) return;
    this.heroService.addHero({name} as Hero)
    .subscribe(hero=>{this.heroes.push(hero);});
  }`

你配置了一个内存 Web API。
`npm install angular-in-memory-web-api --save
app.module.ts
import { HttpClientInMemoryWebApiModule } from 'angular-in-memory-web-api';
import { InMemoryDataService }  from './in-memory-data.service';
in-memory-data.service.ts
import { InMemoryDbService } from 'angular-in-memory-web-api';
export class InMemoryDataService implements InMemoryDbService {
  construct (){}
  createDb() {
    const heroes = [
      { id: 11, name: 'Mr. Nice' } ];
    return {heroes};
  }
}`
你学会了如何使用“可观察对象”。
  `通常，Observable 可以在一段时间内返回多个值。 
  但来自 HttpClient 的 Observable 总是发出一个值，然后结束，再也不会发出其它值。
  使用 RxJS 的 catchError() 操作符来建立对 Observable 结果的处理管道（pipe）
  import { catchError, map, tap } from 'rxjs/operators';
  现在，使用 .pipe() 方法来扩展 Observable 的结果，并给它一个 catchError() 操作符。
  getHeroes (): Observable<Hero[]> {
    return this.http.get<Hero[]>(this.heroesUrl)
      .pipe(
        catchError(this.handleError('getHeroes', []))
      );
  }`
  使用 RxJS的tap查看Observable中的值，使用那些值做一些事情，并且把它们传出来.这种tap回调不会改变这些值本身
  ```/** GET heroes from the server */
  getHeroes (): Observable<Hero[]> {
    return this.http.get<Hero[]>(this.heroesUrl)
      .pipe(
        tap(heroes => this.log(`fetched heroes`)),
        catchError(this.handleError('getHeroes', []))
      );
  }```