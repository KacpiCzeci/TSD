import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { MainMenuComponent } from "./MainMenuComponent/mainmenu.component";
import { AddNoteComponent } from "./AddNoteComponent/addnote.component";

const routes: Routes = [
  { path: "", redirectTo: "/mainmenu", pathMatch: "full" },
  { path: "mainmenu", component: MainMenuComponent },
  { path: "addnote", component: AddNoteComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
