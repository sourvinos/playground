import { Component, ElementRef } from '@angular/core'
import { AbstractControl, FormBuilder, FormGroup } from '@angular/forms'
import { InputTabStopDirective } from './input-tab-stop.directive'

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})

export class AppComponent {

    public form: FormGroup
    public input: InputTabStopDirective
    public selectedMonth: string

    constructor(private formBuilder: FormBuilder, private el: ElementRef) {
        this.initForm()
    }

    public doCalculations(focusField: string): void {
        let netAmount = 0
        let vatAmount = 0
        let grossAmount = 0
        if (focusField == 'netAmount') {
            vatAmount = parseFloat((this.form.value.netAmount * (this.form.value.vatPercent / 100)).toFixed(2))
            grossAmount = (this.form.value.netAmount + vatAmount).toFixed(2)
            this.form.patchValue({ vatAmount: vatAmount })
            this.form.patchValue({ grossAmount: grossAmount })
        }
        if (focusField == 'grossAmount') {
            netAmount = parseFloat((this.form.value.grossAmount / (1 + (this.form.value.vatPercent / 100))).toFixed(2))
            vatAmount = parseFloat((netAmount * (this.form.value.vatPercent / 100)).toFixed(2))
            grossAmount = (this.form.value.netAmount + vatAmount).toFixed(2)
            this.form.patchValue({ netAmount: netAmount })
            this.form.patchValue({ vatAmount: vatAmount })
        }
    }

    private initForm(): void {
        this.form = this.formBuilder.group({
            netAmount: 0.00,
            vatPercent: 24.0,
            vatAmount: 0.00,
            grossAmount: 0.00
        })
    }

    get netAmount(): AbstractControl {
        return this.form.get('netAmount')
    }

    get vatPercent(): AbstractControl {
        return this.form.get('vatPercent')
    }

    get vatAmount(): AbstractControl {
        return this.form.get('vatAmount')
    }

    get grossAmount(): AbstractControl {
        return this.form.get('grossAmount')
    }

}
