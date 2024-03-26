import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class ApiService{
    public constructor(private httpClient: HttpClient){}

    public sendQuery(param: string){
        const queryRoute = `https://localhost:7234/api/order/${param}`;
        return this.httpClient.get<any>(queryRoute);
    }
}