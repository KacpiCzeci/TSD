import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-add-note",
  templateUrl: "./addnote.component.html",
  styleUrls: ["./addnote.component.css"]
})
export class AddNoteComponent implements OnInit {
  text: String | undefined;

  constructor() {}

  ngOnInit(): void {}
}
