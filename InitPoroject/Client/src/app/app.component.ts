import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {ButtonModule } from 'primeng/button';
import {NavBarComponent} from './Components/nav-bar/nav-bar.component';


@Component({
  selector: 'app-root',
  imports: [RouterOutlet, ButtonModule, NavBarComponent],
  templateUrl: './app.component.html',
})
export class AppComponent {
  title = 'Client';
  toggleDarkMode(){
    const element = document.querySelector('html');
    if(element)
      element.classList.toggle("my-app-dark");
  }
}
