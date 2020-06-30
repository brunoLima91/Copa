import { Injectable } from '@angular/core';
import {HttpClient, HttpErrorResponse,HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';
import { Copa } from './copa';
import { retry, catchError } from 'rxjs/operators';

@Injectable()
export class CopaService{
    constructor(private http: HttpClient){}

    public serviceError: string="";
    protected UrlServiceV1: string = "https://localhost:44303/api/copa";

    httpOptions = {
        headers: new HttpHeaders({'Content-Type':'application/json'})
    }
    
    
    obterCopa(): Observable<Copa>{
       // ler Storage
        let equipes = JSON.parse(localStorage.getItem("equipes"));
       // realizar post
          
       return this.http.post<Copa>(this.UrlServiceV1,localStorage.getItem("equipes"), this.httpOptions)
        .pipe(
            retry(2)
           ,catchError(this.handleError
                ) )
       
        //return this.http
        //.get<Copa>(this.UrlServiceV1);

    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
     }


}