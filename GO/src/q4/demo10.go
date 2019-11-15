package main
import "fmt"

var block="package"

func main(){
	fmt.Printf("the blick is %s.\n", block)
	block:="funciton"
	{
		block:="inner"
		fmt.Printf("the blick is %s.\n", block)
	}
	fmt.Printf("the blick is %s.\n", block)
}