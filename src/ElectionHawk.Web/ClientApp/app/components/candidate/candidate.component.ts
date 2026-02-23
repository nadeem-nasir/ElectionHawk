import { Component, OnInit} from '@angular/core';

import { ICandidate } from '../../services/interfaces';
import { CandidateService } from '../../services/candidate.service';

import { TableModule } from 'primeng/table';

@Component({
    selector:'candidate',
    templateUrl:'./candidate.component.html',
})
export class CandidateComponent implements OnInit {

    errorMessage: string;
    candidate: ICandidate[] = [];

    display: boolean = false;

    constructor( private _candidateService: CandidateService) {
        //debugger;
    }
    ngOnInit(): void {
       
        this._candidateService.getCandidatesAll()
            .subscribe(candidate => {
                this.candidate = candidate;
                console.log(this.candidate);
            },
            error => this.errorMessage = <any>error);
    }
}








