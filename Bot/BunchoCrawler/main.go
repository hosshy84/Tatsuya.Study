package main

import (
	"encoding/json"
	"fmt"
	"io/ioutil"
	"net/http"
	"net/url"

	"github.com/PuerkitoBio/goquery"
)

var (
	IncomingUrl string = "https://hooks.slack.com/services/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"
)

type Slack struct {
	Text       string `json:"text"`
	Username   string `json:"username"`
	Icon_emoji string `json:"icon_emoji"`
	Icon_url   string `json:"icon_url"`
	Channel    string `json:"channel"`
}

func GetPage(str string) {
	doc, err := goquery.NewDocument(str)
	if err != nil {
		fmt.Println(err)
	}
	doc.Find("div.sca_table2").Each(func(_ int, s *goquery.Selection) {
		title := s.Find("td.sca_name2 a").Text()
		fmt.Println(title)
		params, _ := json.Marshal(Slack{
			title,
			"BunchoBot",
			"",
			"",
			"#bot_test"})

		resp, _ := http.PostForm(
			IncomingUrl,
			url.Values{"payload": {string(params)}},
		)

		body, _ := ioutil.ReadAll(resp.Body)
		defer resp.Body.Close()

		fmt.Println(string(body))
	})
}

func main() {
	url := "http://pets-kojima.com/small_list/?topics_group_id=4&group=&shop%5B%5D=tokyo01&freeword=%E3%83%96%E3%83%B3%E3%83%81%E3%83%A7%E3%82%A6&price_bottom=&price_upper=&order_type=2"
	GetPage(url)
}
