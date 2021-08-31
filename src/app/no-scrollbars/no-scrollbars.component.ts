import { Component } from '@angular/core'

@Component({
    selector: 'app-no-scrollbars',
    templateUrl: './no-scrollbars.component.html',
    styleUrls: ['./no-scrollbars.component.css']
})

export class NoScrollbarsComponent {

    public items = []
    public suppliers = []

    ngOnInit(): void {
        this.populateItems()
        this.populateSuppliers()
    }

    private populateItems(): void {
        for (let index = 1; index <= 130; index++) {
            this.items.push('Item ' + index)
        }
    }

    private populateSuppliers(): void {
        for (let index = 1; index <= 5; index++) {
            this.suppliers.push('Supplier ' + index)
        }
    }

}
