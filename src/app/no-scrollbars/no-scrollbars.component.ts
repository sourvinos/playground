import { Component } from '@angular/core'

@Component({
    selector: 'app-no-scrollbars',
    templateUrl: './no-scrollbars.component.html',
    styleUrls: ['./no-scrollbars.component.css']
})

export class NoScrollbarsComponent {

    public elements = []
    public upArrow: boolean
    public downArrow: boolean
    public scrollTop: number


    ngOnInit(): void {
        this.populateItems()
    }

    public onWindowScroll(event?: { target: { scrollTop: number; clientHeight: any; scrollHeight: number } }): void {
        this.upArrow = event.target.scrollTop > 0 ? true : false
        this.downArrow = event.target.clientHeight + event.target.scrollTop < event.target.scrollHeight ? true : false
    }

    private populateItems(): void {
        for (let index = 1; index <= 130; index++) {
            this.elements.push('Element ' + index)
        }
    }

}
