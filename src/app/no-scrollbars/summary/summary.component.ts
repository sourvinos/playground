import { Component, Input } from '@angular/core'

@Component({
    selector: 'summary',
    templateUrl: './summary.component.html',
    styleUrls: ['./summary.component.css']
})

export class SummaryComponent {

    @Input() records: any
    @Input() index: any
    @Input() id: any

    public upArrow: boolean[] = []
    public downArrow: boolean[] = []
    public scrollTop: number


    ngAfterViewInit(): void {
        this.showDownArrow(this.index, this.id)
    }

    public onWindowScroll(index, event?: { target: { scrollTop: number; clientHeight: any; scrollHeight: number } }): void {
        this.upArrow[index] = event.target.scrollTop > 0 ? true : false
        this.downArrow[index] = event.target.clientHeight + event.target.scrollTop < event.target.scrollHeight ? true : false
        console.log('')
        console.log('clientHeight', event.target.clientHeight)
        console.log('scrollTop', event.target.scrollTop)
        console.log('scrollHeight', event.target.scrollHeight)
    }

    public scrollToTop(element): void {
        const el = document.getElementById(element)
        console.log('el', el)
        el.scrollTop = Math.max(0, 0)
    }

    public scrollToBottom(element): void {
        const el = document.getElementById(element)
        console.log('el', el)
        el.scrollTop = Math.max(0, el.scrollHeight - el.offsetHeight)
    }

    private showDownArrow(index, element): void {
        const div = document.getElementById(element)
        Promise.resolve(null).then(() => {
            this.downArrow[index] = div.clientHeight + div.scrollTop < div.scrollHeight ? true : false
        })
    }

}
