package main

import (
	"flag"
	"fmt"
	"lib"
)

var name string

func init(){
 	flag.StringVar(&name, "name", "every one", "the greeting object.")
}

func main(){
	fmt.Println("hello world")
	flag.Parse()
	// fmt.Printf("hello, %s!\n", name)
	lib.Hello(name)
}