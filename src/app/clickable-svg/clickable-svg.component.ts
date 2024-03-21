import { Component } from '@angular/core'

@Component({
    selector: 'app-clickable-svg',
    templateUrl: './clickable-svg.component.html',
    styleUrls: ['./clickable-svg.component.css']
})

export class ClickableSvgComponent {

    public doStuff(): void {
        console.log('doing stuff')
    }

}
