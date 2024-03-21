import { NgModule } from '@angular/core'
import { NoPreloading, RouterModule, Routes } from '@angular/router'
import { AppComponent } from './app.component'

const appRoutes: Routes = [
    { path: '', component: AppComponent },
]

@NgModule({
    declarations: [],
    imports: [
        RouterModule.forRoot(appRoutes, {
            onSameUrlNavigation: 'reload',
            preloadingStrategy: NoPreloading,
            useHash: true,
        })
    ],
    exports: [
        RouterModule
    ]
})

export class AppRoutingModule { }
