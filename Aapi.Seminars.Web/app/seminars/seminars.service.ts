import { Injectable } from '@angular/core';

@Injectable()
export class SeminarsService {
    public getSeminars(): any[] {
        return [
            {
                name: 'Summer 2017'
            },
            {
                name: 'Winter 2017'
            },
            {
                name: 'Summer 2019'
            }
        ];
    }
}