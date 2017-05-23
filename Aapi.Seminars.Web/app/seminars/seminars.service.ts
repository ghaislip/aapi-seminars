import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs';

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
}