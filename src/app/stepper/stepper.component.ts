import { Component } from '@angular/core'
import { FormBuilder, FormGroup } from '@angular/forms'

@Component({
    selector: 'stepper',
    templateUrl: './stepper.component.html',
    styleUrls: ['./stepper.component.css']
})

export class StepperComponent {

    seasons: string[] = ['Yes', 'No']

    constructor(private formBuilder: FormBuilder) { }

    firstFormGroup: FormGroup = this.formBuilder.group({
        favoriteSeason: '',
        firstCtrl: ['']
    })

    secondFormGroup: FormGroup = this.formBuilder.group({
        secondCtrl: ['']
    })

    search(): void {
        console.log('Searching...')
    }

}
