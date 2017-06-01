import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs';

export class Seminar {
    public name: string
}

@Injectable()
export class SeminarsService {
    private rootApiUrl: string = 'http://localhost:58270';

    public constructor(private http: Http) { }

    public getSeminars(): Observable<any> {
        const seminarsRelativeUrl: string = 'api/seminars';
        return this.http.get(`${this.rootApiUrl}/${seminarsRelativeUrl}`)
            .map((response: Response) => {
                return response.json();
            });
    }

    public getById(id: number): Observable<Seminar> {
        const seminarsDetailRelativeUrl: string = `api/seminar/${id}`;
        return this.http.get(`${this.rootApiUrl}/${seminarsDetailRelativeUrl}`)
            .map((response: Response) => {
                return response.json();
            });
    }

}