import { Component } from '@angular/core';

import { SeminarsService } from './seminars.service';

@Component({
    templateUrl: './seminars.component.html',
    styleUrls: ['./seminars.component.scss']
})
export class SeminarsComponent {
    public seminarsViewModel: any = {};

    public constructor(private seminarsService: SeminarsService) {
        this.seminarsService.getSeminars()
            .subscribe((seminarsViewModel: any) => {
                this.seminarsViewModel = seminarsViewModel;
            });
    }
}