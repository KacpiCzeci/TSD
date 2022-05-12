import { Component, OnInit } from "@angular/core";
import { MovieListService } from "../movielist.service";
import Note from "../note.ts";
import { Router } from "@angular/router";

@Component({
  selector: "app-add-note",
  templateUrl: "./addnote.component.html",
  styleUrls: ["./addnote.component.css"]
})
export class AddNoteComponent implements OnInit {
  text: string;

  add(text: string): void {
    text = text.trim();
    if (!text) {
      return;
    }

    this.movieListService.addList({ id: null, text: text, date: null } as Note);
  }

  redirect(): void {
    this.router.navigate(["/mainmenu"]);
  }

  constructor(
    private movieListService: MovieListService,
    private router: Router
  ) {}

  ngOnInit(): void {}
}
