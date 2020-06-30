import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {RouterModule} from '@angular/router';
import {APP_BASE_HREF} from '@angular/common';
import {FormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';


import { AppComponent } from './app.component';
import { MenuComponent } from './navegacao/menu/menu.component';
import { FooterComponent } from './navegacao/footer/footer.component';
import { ListarEquipeComponent } from './equipes/listar-equipe/listar-equipe.component';
import { rootRouterConfig } from './app.routes';
import { EquipeService } from './equipes/equipe.service';
import { ResultadoCopaComponent } from './copa/resultado-copa/resultado-copa.component';
import {CopaService} from './copa/copa.service';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    FooterComponent,
    ListarEquipeComponent,
    ResultadoCopaComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    [RouterModule.forRoot(rootRouterConfig,{ useHash: false})]
  ],
  providers: [
    EquipeService,
    CopaService,
    {provide: APP_BASE_HREF, useValue: '/'}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
