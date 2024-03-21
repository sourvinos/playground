import { Component, HostListener } from '@angular/core'

@Component({
    selector: 'scroll-to-position',
    templateUrl: './scroll-to-position.component.html',
    styleUrls: ['./scroll-to-position.component.css']
})

export class ScrollToPositionComponent {

    private scrolled: any

    @HostListener('window:scroll', ['$event'])

    ngOnInit(): void {
        const savedPosition = localStorage.getItem('position')
        if (savedPosition) {
            document.getElementById('scrollable').scrollBy(0, parseInt(savedPosition))
        }
    }

    onScroll(e: Event) {
        this.scrolled = this.getScrollTop(e)
        localStorage.setItem('position', this.scrolled)
    }

    public savePosition(): void {
        localStorage.setItem('position', this.scrolled)
    }

    private getScrollTop(e: Event): number {
        return (e.target as Element).scrollTop
    }

}
