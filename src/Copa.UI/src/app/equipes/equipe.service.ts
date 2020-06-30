import{Injectable} from '@angular/core';
import{HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { Equipe } from './equipe';


@Injectable()
export class EquipeService{
    constructor(private http: HttpClient){}

    protected UrlServiceV1: string = "https://raw.githubusercontent.com/dougramalho/labs/master/ZCRQS/equipes.json";

    obterEquipes(): Observable<Equipe[]>{
        return this.http
        .get<Equipe[]>(this.UrlServiceV1)
    }
}