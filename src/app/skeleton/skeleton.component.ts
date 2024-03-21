import { Component, ElementRef } from '@angular/core'

@Component({
    selector: 'skeleton-rect',
    templateUrl: './skeleton.component.html',
    styleUrls: ['./skeleton.component.css']
})

export class RectComponent {

    width: string
    height: string
    className: string

    constructor(private host: ElementRef<HTMLElement>) { }

    ngOnInit() {
        const host = this.host.nativeElement
        if (this.className) {
            host.classList.add(this.className)
        }
        host.style.setProperty('--skeleton-rect-width', this.width ?? '100%')
        host.style.setProperty('--skeleton-rect-height', this.height ?? '20px')
    }

}