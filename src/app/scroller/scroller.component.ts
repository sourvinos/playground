import { ChangeDetectionStrategy, Component, ViewEncapsulation } from '@angular/core'

@Component({
    selector: 'scroller',
    templateUrl: './scroller.component.html',
    styleUrls: ['./scroller.component.css'],
    encapsulation: ViewEncapsulation.None,
    changeDetection: ChangeDetectionStrategy.OnPush
})

export class ScrollerComponent {

    items = Array.from({ length: 100000 }).map((_, i) => `Item #${i}`)

    ngOnInit(): void {
        this.enableHorizontalScroll(document.querySelector('.cdk-virtual-scrollable'))
    }

    public enableHorizontalScroll(element: any): any {
        element.addEventListener('wheel', (evt: WheelEvent) => {
            evt.preventDefault()
            element.scrollLeft += evt.deltaY
        }, 1000)
    }

}
