import { AppComponent } from './app.component'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { BrowserModule } from '@angular/platform-browser'
import { DropdownModule } from 'primeng/dropdown'
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { HttpClientModule } from '@angular/common/http'
import { MatDialogModule } from '@angular/material/dialog'
import { MatSelectModule } from '@angular/material/select'
import { MultiSelectModule } from 'primeng/multiselect'
import { NgModule } from '@angular/core'
import { TableModule } from 'primeng/table'
// Material
import { MatIconModule } from '@angular/material/icon'
import { MatListModule } from '@angular/material/list'
import { MatMenuModule } from '@angular/material/menu'
// Components
import { DatesComponent } from '../dates/dates.component'
import { NoScrollbarsComponent } from '../no-scrollbars/no-scrollbars.component'
import { SummaryComponent } from '../no-scrollbars/summary/summary.component'

// Pipes
import { DateFormat } from '../date-format.pipe'

@NgModule({
    declarations: [
        AppComponent,
        NoScrollbarsComponent,
        SummaryComponent,
        DatesComponent,
        DateFormat
    ],
    imports: [
        BrowserAnimationsModule,
        BrowserModule,
        DropdownModule,
        FormsModule,
        HttpClientModule,
        MatDialogModule,
        MatIconModule,
        MatListModule,
        MatMenuModule,
        MatSelectModule,
        MultiSelectModule,
        ReactiveFormsModule,
        TableModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})

export class AppModule { }
