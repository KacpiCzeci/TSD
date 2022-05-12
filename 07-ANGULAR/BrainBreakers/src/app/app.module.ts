import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";

import { AppComponent } from "./app.component";
import { NotesComponent } from "./NotesComponent/notes.component";
import { MainMenuComponent } from "./MainMenuComponent/mainmenu.component";
import { AddNoteComponent } from "./AddNoteComponent/addnote.component";
import { AppRoutingModule } from "./app-routing.module";

@NgModule({
  declarations: [
    AppComponent,
    NotesComponent,
    MainMenuComponent,
    AddNoteComponent
  ],
  imports: [BrowserModule, AppRoutingModule, FormsModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
