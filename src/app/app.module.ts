import { AppComponent } from './app.component'
import { AppRoutingModule } from './app-routing.module'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { BrowserModule } from '@angular/platform-browser'
import { CommonModule, registerLocaleData } from '@angular/common'
import { FormsModule, ReactiveFormsModule } from '@angular/forms'
import { HttpClientModule } from '@angular/common/http'
import { LOCALE_ID, NgModule } from '@angular/core'
import localeEL from '@angular/common/locales/el'
registerLocaleData(localeEL)
// PrimeNg
import { ButtonModule } from 'primeng/button'
import { CarouselModule } from 'primeng/carousel'
// Material
import { DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE, MatNativeDateModule, NativeDateModule } from '@angular/material/core'
import { ScrollingModule } from '@angular/cdk/scrolling'
import { MAT_MOMENT_DATE_ADAPTER_OPTIONS, MAT_MOMENT_DATE_FORMATS, MomentDateAdapter } from '@angular/material-moment-adapter'
import { MatButtonModule } from '@angular/material/button'
import { MatButtonToggleModule } from '@angular/material/button-toggle'
import { MatCardModule } from '@angular/material/card'
import { MatDatepickerModule } from '@angular/material/datepicker'
import { MatDialogModule } from '@angular/material/dialog'
import { MatIconModule } from '@angular/material/icon'
import { MatInputModule } from '@angular/material/input'
import { MatRadioModule } from '@angular/material/radio'
import { MatSelectModule } from '@angular/material/select'
import { MatStepperModule } from '@angular/material/stepper'
// Custom
import { CalculationsComponent } from './calculations/calculations.component'
import { ClickableSvgComponent } from './clickable-svg/clickable-svg.component'
import { DecimalInputDirective } from './decimal-input.directive'
import { InputTabStopDirective } from './input-tab-stop.directive'
import { MonthSelectorComponent } from './month-selector/month-selector.component'
import { RectComponent } from './skeleton/skeleton.component'
import { ScrollToPositionComponent } from './scroll-to-position/scroll-to-position.component'
import { ScrollerComponent } from './scroller/scroller.component'
import { SkeletonDirective } from './skeleton/skeleton.directive'
import { StepperComponent } from './stepper/stepper.component'
import { DynamicControlsComponent } from './dynamic-controls/dynamic-controls.component'
import { LocalizedNumericInputDirective } from './number-seperator.directive';
import { UploadComponent } from './upload/upload.component'
import { InvoiceFormComponent } from './pdf/invoice-form.component'

@NgModule({
    declarations: [
        AppComponent,
        CalculationsComponent,
        ClickableSvgComponent,
        DecimalInputDirective,
        InputTabStopDirective,
        MonthSelectorComponent,
        RectComponent,
        ScrollToPositionComponent,
        ScrollerComponent,
        SkeletonDirective,
        LocalizedNumericInputDirective,
        StepperComponent,
        InvoiceFormComponent,
        DynamicControlsComponent,
        UploadComponent
    ],
    imports: [
        AppRoutingModule,
        BrowserAnimationsModule,
        BrowserModule,
        ButtonModule,
        CarouselModule,
        CommonModule,
        FormsModule,
        HttpClientModule,
        MatButtonModule,
        MatButtonToggleModule,
        MatCardModule,
        MatDatepickerModule,
        MatDialogModule,
        MatIconModule,
        MatInputModule,
        MatNativeDateModule,
        MatRadioModule,
        MatSelectModule,
        MatStepperModule,
        NativeDateModule,
        ReactiveFormsModule,
        ScrollingModule
    ],
    providers: [
        { provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE, MAT_MOMENT_DATE_ADAPTER_OPTIONS] },
        { provide: MAT_DATE_FORMATS, useValue: MAT_MOMENT_DATE_FORMATS },
        { provide: MAT_DATE_LOCALE, useValue: '' },
        { provide: LOCALE_ID, useValue: 'el-GR' },
        { provide: MAT_MOMENT_DATE_ADAPTER_OPTIONS, useValue: { useUtc: true } },
    ],
    bootstrap: [AppComponent]
})

export class AppModule { }
