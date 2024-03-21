import { Component } from '@angular/core'
import { AbstractControl, FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms'
import { InputTabStopDirective } from '../input-tab-stop.directive'

@Component({
    selector: 'app-dynamic-controls',
    templateUrl: './dynamic-controls.component.html',
    styleUrls: ['./dynamic-controls.component.css']
})

export class DynamicControlsComponent {

    public form: FormGroup
    public input: InputTabStopDirective

    private numberOfAddresses = 5

    constructor(private formBuilder: FormBuilder) { }

    ngOnInit(): void {
        this.initForm()
        for (let index = 0; index < this.numberOfAddresses - 1; index++) {
            this.addresses.push(this.getAddressControl())
        }
    }

    public addAddress(): void {
    }

    private initForm(): void {
        this.form = this.formBuilder.group({
            id: 0,
            description: ['', [Validators.required, Validators.maxLength(128)]],
            profession: ['', [Validators.maxLength(128)]],
            addresses: this.formBuilder.array([
                this.getAddressControl()
            ]),
        })
    }

    private getAddressControl(): FormGroup {
        const address = this.formBuilder.group({
            streetName: 'boo'
        })
        return address
    }

    get description(): AbstractControl {
        return this.form.get('description')
    }

    get profession(): AbstractControl {
        return this.form.get('profession')
    }

    get address(): AbstractControl {
        return this.form.get('address')
    }

    get addresses(): FormArray {
        return <FormArray>this.form.get('addresses')
    }

}
