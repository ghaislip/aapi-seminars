import { Component } from '@angular/core';

import { SeminarsService } from './seminars.service';

@Component({
    templateUrl: './seminars.component.html',
    styleUrls: ['./seminars.component.scss']
})
export class SeminarsComponent {
    public seminars: any[];

    public constructor(private seminarsService: SeminarsService) {
        this.seminars = this.seminarsService.getSeminars();
    }
}