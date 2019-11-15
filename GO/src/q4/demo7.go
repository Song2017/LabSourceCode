package main

import (
  "flag"
  "fmt"
)

func main() {
//   var name string // [1]
//   flag.StringVar(&name, "name", "everyone", "The greeting object.") // [2]
// flag.Parse()
// fmt.Printf("Hello, %v!\n", name)

//   var name = flag.String("name", "every one", "greerting help")
//   flag.Parse()
//   fmt.Printf("Hello, %v!\n", *name)

	// name := flag.String("name", "every one", "greerting help")
	// flag.Parse()
	// fmt.Printf("Hello, %v!\n", *name)
	
	name := getTheFlag()
	flag.Parse()
	fmt.Printf("Hello, %v!\n", *name)
}

func getTheFlag() *string{
	return flag.String("name", "every one", "greerting help")
}
