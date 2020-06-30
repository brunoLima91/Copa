import{Routes } from '@angular/router'
import { ListarEquipeComponent } from './equipes/listar-equipe/listar-equipe.component';
import { ResultadoCopaComponent } from './copa/resultado-copa/resultado-copa.component';

export const rootRouterConfig: Routes = [
    {path: '', redirectTo:'/home', pathMatch: 'full'},
    {path:'home', component: ListarEquipeComponent},
    {path:'copa', component: ResultadoCopaComponent}
];