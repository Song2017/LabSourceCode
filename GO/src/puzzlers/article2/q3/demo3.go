package main

import (
	"flag"
	"fmt"
	"os"
)

var name string

// 方式3。
var cmdLine = flag.NewFlagSet("question333", flag.ExitOnError)

func init() {
	// 方式2。
	// flag.CommandLine = flag.NewFlagSet("", flag.PanicOnError)
	// flag.CommandLine.Usage = func() {
	// 	fmt.Fprintf(os.Stderr, "Usage of %s:\n", "question222")
	// 	flag.PrintDefaults()
	// }
	// 方式3。
	//cmdLine.StringVar(&name, "name", "everyone", "The greeting object.")
	flag.StringVar(&name, "name", "everyone", "The greeting object.")
}

func main() {
	// 方式1。
	//flag.Usage = func() {
	//	fmt.Fprintf(os.Stderr, "Usage of %s:\n", "question")
	//	flag.PrintDefaults()
	//}
	// 方式3。
	cmdLine.Parse(os.Args[:])
	flag.Parse()
	fmt.Printf("Hello, %s!\n", name)
}
