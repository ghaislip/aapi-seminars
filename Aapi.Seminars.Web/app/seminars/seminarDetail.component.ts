import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';

import { Seminar, SeminarsService } from "./seminars.service";

@Component({
    templateUrl: './seminarDetail.component.html',
    styleUrls: ['./seminarDetail.component.scss']
})
export class SeminarDetailComponent implements OnInit {
    public seminar: Seminar;

    public constructor(
        private route: ActivatedRoute,
        private seminarsService: SeminarsService
    ) {
        this.seminar = <Seminar>{};
    }

    ngOnInit() {
        this.route.params
            .subscribe((params: Params) => this.seminarsService.getById(+params['id'])
                .subscribe((seminar: Seminar) => this.seminar = seminar));
    }
}