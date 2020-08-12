package main

import (
	"encoding/json"
	"fmt"
	"github.com/gorilla/mux"
	"math/rand"
	"net/http"
	"strconv"
)

type Article struct {
	Number int
}

func homePage(w http.ResponseWriter, r *http.Request) {
	min, err := strconv.Atoi(r.URL.Query().Get("min"))
	if err != nil {
		panic(err)
	}

	max, err := strconv.Atoi(r.URL.Query().Get("max"))
	if err != nil {
		panic(err)
	}

	n := rand.Intn(max-min) + min

	article := Article{Number: n}

	json.NewEncoder(w).Encode(article)
}

func main() {
	router := mux.NewRouter()

	router.HandleFunc("/random", homePage).Methods("GET")

	err := http.ListenAndServe(":3000", router)
	if err != nil {
		fmt.Println(err)
	}
}
