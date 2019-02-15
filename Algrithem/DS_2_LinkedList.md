
## Linked List 链表 
链表是一种物理存储单元上非连续、非顺序的线性存储结构,通过指针将一组零散的内存块(结点)串联在一起.
组成链表的结点可以在运行时动态生成, 这就克服了数组需要预先知道数据大小的缺点
### 优劣
优势: 
1. 离散分布: 结点之间的逻辑关系通过next指针确定, 结点离散的存储在内存中, 不需要占用连续的大内存块
2. 动态扩充: 只需要将尾结点由NULL指向新结点就实现了链表的扩充, 不需要像数组那样创建时就指定长度
3. 类型多样: next指针指向的是内存地址, 解除了对结点类型的限制
4. 操作简单: 增加, 将当前节点的指针指向新增结点, 新增结点的地址指向后继结点
        删除, 将前驱结点的指针指向后继结点的地址, 时间复杂度都是O(1)

劣势:
1. 离散分布和对结点数据类型的放松, 使得链表的查找只能通过next指针一个一个的遍历定位.
没有了随机访问特性, 时间复杂度是O(n)
2. 链表结点除了存储数据, 还要存储表明逻辑结点间逻辑的指针, 需要更多的内存.
3. 失去了数组的局部缓存特性
### 分类
结点: 组成链表的离散内存块. 
头结点: 第一个结点, 用来记录链表的基地址; 尾结点: 最后一个结点
后继指针(next): 记录下个结点地址的指针, 串联结点的关键
分类的标准:结点的数据结构与尾结点后继指针的指向
#### 结点结构
python实现基本数据结构无法保证内存位置是在栈还是堆,失去了基本数据结构的操作优势, 
所以下面的代码实现是C代码
1. 单链表结点
    struct Node 
    {   
        int data; //数据 int是示例类型, 可以是其他简单数据类型
        struct Node *next; // 后继结点的指针
    };
2.  双向链表结点
    struct Node { 
        int data; 
        struct Node* next; // 后继结点的指针
        struct Node* prev; // 前驱结点的指针
    };
#### 单链表 
单链表采用单链表结点, 尾结点指向空地址NULL的链表 
```
#include <stdio.h>
#include <stdlib.h>

struct Node
{
	int		data;
	struct Node	*next;
};
void printList( struct Node *n )
{
	while ( n != NULL )
	{
		printf( " %d ", n->data );
		n = n->next;
	}
}
int main()
{
	struct Node	* head	= NULL;
	struct Node	* sec	= NULL;
	struct Node	* third = NULL;
	head		= (struct Node *) malloc( sizeof(struct Node) );
	sec		= (struct Node *) malloc( sizeof(struct Node) );
	third		= (struct Node *) malloc( sizeof(struct Node) );
	head->data	= 1;
	head->next	= sec;
	sec->data	= 2;
	sec->next	= third;
	third->data	= 3;
	third->next	= NULL;

	printList( head ); /* 1 2 3 */
}
```
#### 循环链表
循环链表是一种特殊的单链表, 尾结点指向链表的头结点, 像是衔尾蛇
约瑟夫问题: 5个人围成一圈,从第一个开始报数,第3个将被杀掉,最后剩下一个,其余人都将被杀掉 
```
#include <stdio.h>
#include <stdlib.h>
struct Human {
	int		live;
	int		ID;
	struct Human	*next;
};
void printJosephus( struct Human *n, int count )
{
	int interval = 3;
	while ( count > 0 )
	{
		if ( n->live == 1 )
		{
			interval = interval - 1;

			if ( interval == 0 )
			{
				n->live		= 0;
				interval	= 3;
				printf( " %d ", n->ID );

				count = count - 1;
			}
		}
		n = n->next;
	}
}

int main()
{
	struct Human	* head	= NULL;
	struct Human	* sec	= NULL;
	struct Human	* third = NULL;
	struct Human	* four	= NULL;
	struct Human	* fiv	= NULL;
	head	= (struct Human *) malloc( sizeof(struct Human) );
	sec	= (struct Human *) malloc( sizeof(struct Human) );
	third	= (struct Human *) malloc( sizeof(struct Human) );
	four	= (struct Human *) malloc( sizeof(struct Human) );
	fiv	= (struct Human *) malloc( sizeof(struct Human) );

	head->ID	= 1; head->live = 1; head->next = sec;
	sec->ID		= 2; sec->live = 1; sec->next = third;
	third->ID	= 3; third->live = 1; third->next = four;
	four->ID	= 4; four->live = 1; four->next = fiv;
	fiv->ID		= 5; fiv->live = 1; fiv->next = head;

	printJosephus( head, 5 );//3 1 5 2 4
}
```
#### 双向链表
采用双向结点的链表, 结点同时记住前驱结点和后继结点的地址
1. 删除操作细分
按值删除: 为了找到等于给定值的结点, 需要一一遍历结点, 不仅是链表,包括数组, 查找的时间复杂度都是O(n)
按指针删除: 我们已经知道要删除的结点, 但删除链表结点要将前驱结点的next指针指向后继结点.
对单链表, 需要遍历链表, 直到p->next=当前结点, 为O(n); 
但双向链表的结点存储前驱结点地址, 时间复杂度为O(1)
2. 查找
当链表有序存储时, 可以记录当前结点作为分界点,用二分算法决定查找方向, 减少一半时间
相对单向链表, 每个结点的存储开销进一步增多
#### 双向循环链表
使用双向链表结点, 尾结点的后置指针指向首结点, 首结点的前驱指针指向尾结点
### LRU 单链表实现
```
    #include <stdio.h>
    #include <stdlib.h>
    
    struct Node {
        int		data;
        struct Node	*next;
    };
    
    
    void printList( struct Node *n )
    {
        while ( n != NULL )
        {
            printf( " %d ", n->data );
            n = n->next;
        }
    }
    
    
    int existsInSingleLink( struct Node* head, int newvalue )
    {
        int exists = 0;
        while ( head->next != NULL )
        {
            if ( head->data == newvalue )
            {
                exists = 1;
                break;
            }
            head = head->next;
        }
    
        return(exists);
    }
    
    
    int lengthSingleLink( struct Node* head )
    {
        int count = 0;
        while ( head != NULL )
        {
            count	= count + 1;
            head	= head->next;
        }
    
        return(count);
    }
    
    
    void delSingleLinkViaValue( struct Node** headref, int data )
    {
        struct Node* temp = *headref, *prev;
        /* delete first node */
        if ( temp != NULL && temp->data == data )
        {
            (*headref) = temp->next;
            free( temp );
            return;
        }
        while ( temp != NULL && temp->data != data )
        {
            prev	= temp;
            temp	= temp->next;
        }
        /* no value found */
        if ( temp == NULL )
            return;
        prev->next = temp->next;
        free( temp );
    }
    
    
    void delSingleLinkViaPos( struct Node** headref, int pos )
    {
        struct Node* temp = *headref;
        if ( temp == NULL )
        {
            return;
        }
    
        /* delete first node */
        if ( pos == 0 )
        {
            *headref = temp->next;
            free( temp );
            return;
        }
        for ( int i = 0; temp != NULL && i < pos - 1; i++ )
            temp = temp->next;
    
        /*  no value found */
        if ( temp == NULL || temp->next == NULL )
            return;
    
        struct Node *next = temp->next->next;
    
        free( temp->next );
    
        temp->next = next;
    }
    
    
    /* Least recently used */
    void LRU( struct Node** head, struct Node* newnode )
    {
        int		cacheSize	= 5;
        int		exists		= 0;
        int		newvalue	= newnode->data;
        struct Node	* temp		= *head; 

        /* node exists, then delete origin and insert new node at the top */
        if ( existsInSingleLink( temp, newvalue ) > 0 )
        {
            /* newnode at the top now */
            if ( temp->data == newnode->data )
                return;
            /* ? newnode->data become 0 */
            delSingleLinkViaValue( head, newvalue );
            printf( "\nLRU3, %d  ...\n", newnode->data );
            newnode->data	= newvalue;
        }else{
            /* when cache size up to top, remove last one */
            if ( lengthSingleLink( temp ) >= cacheSize )
            {
                delSingleLinkViaPos( head, cacheSize - 1 );
            } 
        }
 
        newnode->next	= (*head);
        (*head)		= newnode;
    }
    
    
    int main()
    {
        struct Node	* head	= NULL;
        struct Node	* sec	= NULL;
        struct Node	* third = NULL;
        struct Node	* four	= NULL;
        struct Node	* fiv	= NULL;
        struct Node	* six	= NULL;
        head	= (struct Node *) malloc( sizeof(struct Node) );
        sec	= (struct Node *) malloc( sizeof(struct Node) );
        third	= (struct Node *) malloc( sizeof(struct Node) );
        four	= (struct Node *) malloc( sizeof(struct Node) );
        fiv	= (struct Node *) malloc( sizeof(struct Node) );
        six	= (struct Node *) malloc( sizeof(struct Node) );
    
        head->data	= 1;  head->next = sec;
        sec->data	= 2;  sec->next = third;
        third->data	= 3;  third->next = four;
        four->data	= 4;  four->next = NULL;
        fiv->data	= 5;  fiv->next = NULL;
        six->data	= 6;  six->next = NULL;
    
        LRU( &head, fiv );
        printList( head );
        printf( "__\n" );
        LRU( &head, fiv );
        printList( head );
        printf( "__\n" );
        LRU( &head, third );
        printList( head );
        printf( "__\n" );
        LRU( &head, six );
        printList( head );
        printf( "__\n" );
    }
    
```

### 链表代码技巧
#### 1. 理解指针或引用的含义
C语言中*指针*的概念, Python, C#中*引用*的概念都是指**存储所指对象的内存地址**
    指针变量或引用变量存储的并不是对象本身, 而是对象本身所在内存块的地址.
将变量赋值给指针,实际上就是将这个变量的地址赋值给指针,
    或者反过来说,指针存储了这个变量的内存地址,这个地址指向这个变量本身,通过指针就能找到这个变量.
head->next = sec: head结点的next指针存储了sec结点的内存地址
#### 2. 警惕指针丢失和内存泄漏
向结点p,q之间插入x, 注意插入的顺序
    错误
        p->next = x;  // 将 p 的 next 指针指向 x 结点；
        //将x的结点的next指针指向b结点；p->next中存储x本身; 此时结点q及其后续的结点都丢失了
        x->next = p->next;  
    正确
        x->next = p->next;//p->next就是结点q
        p->next = x
删除结点, 注意手工释放内存空间
    struct Node *next = temp->next->next;
    free( temp->next );
    temp->next = next;
#### 3. 利用哨兵简化实现难度
针对链表的插入、删除操作,需要对插入第一个节点和删除最后一个节点的情况进行特殊处理.
如果我们引入"哨兵"节点,则不管链表是否为空,head指针都会指向这个"哨兵"节点, 代码逻辑可以实现统一
我们把这种有"哨兵"节点的链表称为带头链表,相反,没有"哨兵"节点的链表就称为不带头链表
#### 4. 重点留意边界问题
道生一, 一生二, 二生万物. 
检查链表为空, 只有一个结点, 只有二个结点时代码能否工作
#### 5. 利用工具帮助思考
1. 解决前,要思考,但半小时还没有思路的话可以利用网络搜索方案
2. 解决时,可以写一写, 划一划将问题的内容和条件落实到纸面, 思考的重点放到解决问题上

LeetCode对应编号：206，141，21，19，876