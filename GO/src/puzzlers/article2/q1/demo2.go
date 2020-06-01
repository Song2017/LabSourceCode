package main

import (
	"flag"
	"fmt"
)

// var name string

func init() {
	// flag.StringVar(&name, "name", "everyone", "The greeting object.")
	
}

func main() {
	var name = flag.String("name", "everyone", "The greeting object.")
	flag.Parse()
	fmt.Printf("Hello, %s!\n", *name)
}
