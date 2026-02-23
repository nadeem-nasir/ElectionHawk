import { NgModule, ElementRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavLeftMenuComponent } from './components/navmenu/navleftmenu.component';
import { NavHeaderMenuComponent } from './components/navmenu/navheader.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { AgendaComponent } from './components/campaign/agenda.component';
import { AgendaCreateComponent } from './components/campaign/agenda-create.component';
import { AgendaEditComponent } from './components/campaign/agenda-edit.component';import { CampaignComponent } from './components/campaign/campaign.component';
import { CampaignCreateComponent } from './components/campaign/campaign-create.component';
import { CampaignEditComponent } from './components/campaign/campaign-edit.component';

import { CandidateComponent } from './components/candidate/candidate.component';
import { CandidateCreateComponent } from './components/candidate/candidate-create.component';
import { CandidateEditComponent } from './components/candidate/candidate-edit.component';
import { ConstituencyComponent } from './components/constituency/constituency.component';
import { ConstituencyCreateComponent } from './components/constituency/constituency-create.component';
import { ConstituencyEditComponent } from './components/constituency/constituency-edit.component';
import { ElectionComponent } from './components/election/election.component';
import { ElectionCreateComponent } from './components/election/election-create.component';
import { ElectionEditComponent } from './components/election/election-edit.component';
import { EventComponent } from './components/event/event.component';
import { EventCreateComponent } from './components/event/event-create.component';
import { EventEditComponent } from './components/event/event-edit.component';
import { ExpenseComponent } from './components/expense/expense.component';
import { ExpenseCreateComponent } from './components/expense/expense-create.component';
import { ExpenseEditComponent } from './components/expense/expense-edit.component';
import { MapComponent } from './components/map/map.component';
import { MapCreateComponent } from './components/map/map-create.component';
import { MapEditComponent } from './components/map/map-edit.component';
import { NewsCreateComponent } from './components/news/news-create.component';
import { NewsEditComponent } from './components/news/news-edit.component';
import { NewsComponent } from './components/news/news.component';
import { NewsListComponent } from './components/news/news-list.component';

import { NotificationComponent } from './components/notification/notification.component';
import { NotificationCreateComponent } from './components/notification/notification-create.component';
import { NotificationEditComponent } from './components/notification/notification-edit.component';
import { PoliticalPartyComponent } from './components/politicalparty/politicalparty.component';
import { PoliticalPartyCreateComponent } from './components/politicalparty/politicalparty-create.component';
import { PoliticalPartyEditComponent } from './components/politicalparty/politicalparty-edit.component';
import { PollingSchemeCreateComponent } from './components/pollingscheme/pollingscheme-create.component';
import { PollingSchemeEditComponent } from './components/pollingscheme/pollingscheme-edit.component';
import { PollingSchemeComponent } from './components/pollingscheme/pollingscheme.component';

import { ProfileComponent } from './components/profile/profile.component';
import { ProfileEditComponent } from './components/profile/profile-edit.component';
import { ProfileCreateComponent } from './components/profile/profile-create.component';
import { VoterslistComponent } from './components/voterslist/voterslist.component';
import { VoterslistEditComponent } from './components/voterslist/voterslist-edit.component';
import { VoterslistCreateComponent } from './components/voterslist/voterslist-create.component';
//import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
//import { CounterComponent } from './components/counter/counter.component';

/* Account login , registration, social logins*/
import { CoreModule } from  '../app/core/core.module';//'@app/core';
import { HomeModule } from './home/home.module';
import { routing } from './app.routes';
import { AppService } from './app.service';
import { CampaignService } from './services/campaign.service';
import { AgendaService } from './services/agenda.service';
import { CandidateService } from './services/candidate.service';
import { ConstituencyService } from './services/constituency.service';
import { EventService } from './services/event.service';
import { ElectionService } from './services/election.service';
import { ExpenseService } from './services/expense.service';
import { MapService } from './services/map.service';
import { NewsService } from './services/news.service';
import { NotificationService } from './services/notification.service';
import { PoliticalPartyService } from './services/politicalparty.service';
import { PollingSchemeService } from './services/pollingscheme.service';
import { ProfileService } from './services/profile.service';
import { ProfileTypeService } from './services/profiletype.service';
import { VoterslistService } from './services/voterslist.service';
import { CalendarModule, DropdownModule } from 'primeng/primeng';
import { Configuration} from './services/app.constants';
import { TableModule } from 'primeng/table';
/*end account login, etc */

/* home */
import { HomeComponent } from './home/home.component';;
/*end home  */
@NgModule({
    declarations: [
        AppComponent,
        NavLeftMenuComponent,
        NavHeaderMenuComponent,
        DashboardComponent,
        AgendaComponent,
        AgendaCreateComponent,
        AgendaEditComponent,
        CampaignComponent,
        CandidateComponent,
        ConstituencyComponent,
        EventComponent,
        ElectionComponent,
        ExpenseComponent, 
        MapComponent,
        NewsCreateComponent,
        NewsEditComponent,
        NotificationComponent,
        PoliticalPartyComponent,
        PollingSchemeComponent,
        ProfileComponent,
        VoterslistComponent,
        NewsComponent,
        CampaignCreateComponent,
		CampaignEditComponent,
		CandidateCreateComponent,
		CandidateEditComponent,
		ConstituencyCreateComponent,
		ConstituencyEditComponent,
        NewsComponent,
        NewsListComponent,
        EventCreateComponent,
        EventEditComponent,
		ExpenseCreateComponent,
		ExpenseEditComponent,
		ElectionCreateComponent,
		ElectionEditComponent,
		MapCreateComponent,
		MapEditComponent,
		NotificationCreateComponent,
		NotificationEditComponent,
PoliticalPartyCreateComponent,
PoliticalPartyEditComponent,
ProfileCreateComponent,
ProfileEditComponent,
PollingSchemeCreateComponent,
PollingSchemeEditComponent,
VoterslistEditComponent,
VoterslistCreateComponent		
    ],
    imports: [

        CommonModule,
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        routing,
        CoreModule.forRoot(),
        HomeModule,
        CalendarModule,
        DropdownModule,
        TableModule,
        RouterModule.forRoot([
            {
             path: '', redirectTo: '/public', pathMatch: 'full' },
            { path: 'dashboard', component: DashboardComponent },
            //{ path: 'login', loadChildren: './account/+login/login.module#LoginModule'},
            //{ path: 'counter', component: CounterComponent },
            //{ path: 'fetch-data', component: FetchDataComponent },
            { path: 'public', component:HomeComponent },
            { path: 'agenda', component: AgendaComponent },
            { path: 'agenda-create', component: AgendaCreateComponent },
            { path: 'agenda-edit', component: AgendaEditComponent },
			{ path: 'campaign', component: CampaignComponent },
            { path: 'campaign-create', component: CampaignCreateComponent },
            { path: 'campaign-edit', component: CampaignEditComponent },
            { path: 'candidate', component: CandidateComponent },
            { path: 'candidate-create', component: CandidateCreateComponent },
            { path: 'candidate-edit', component: CandidateEditComponent },
            { path: 'constituency', component: ConstituencyComponent },
            { path: 'constituency-create', component: ConstituencyCreateComponent },
            { path: 'constituency-edit', component: ConstituencyEditComponent },
            { path: 'election', component: ElectionComponent },
            { path: 'election-create', component: ElectionCreateComponent },
            { path: 'election-edit', component: ElectionEditComponent },
            { path: 'event', component: EventComponent },
            { path: 'event-create', component: EventCreateComponent },
            { path: 'event-edit', component: EventEditComponent },
            { path: 'expense', component: ExpenseComponent },
            { path: 'expense-create', component: ExpenseCreateComponent },
            { path: 'expense-edit', component: ExpenseEditComponent },
            { path: 'news-create', component: NewsCreateComponent }, 
            { path: 'news-edit', component: NewsEditComponent },
            { path: 'news-list', component: NewsListComponent },
            { path: 'map', component: MapComponent },
            { path: 'map-create', component: MapCreateComponent },
            { path: 'map-edit', component: MapEditComponent },
            { path: 'notification', component: NotificationComponent },
            { path: 'notification-create', component: NotificationCreateComponent },
            { path: 'notification-edit', component: NotificationEditComponent },
            { path: 'politicalparty', component: PoliticalPartyComponent },
            { path: 'politicalparty-create', component: PoliticalPartyCreateComponent },
            { path: 'politicalparty-edit', component: PoliticalPartyEditComponent },
            { path: 'pollingscheme', component: PollingSchemeComponent },
            { path: 'pollingscheme-create', component: PollingSchemeCreateComponent },
            { path: 'pollingscheme-edit', component: PollingSchemeEditComponent },
            { path: 'voterslist', component: VoterslistComponent },
            { path: 'voterslist-create', component: VoterslistCreateComponent },
            { path: 'voterslist-edit', component: VoterslistEditComponent },
            { path: 'profile', component: ProfileComponent },
            { path: 'profile-create', component: ProfileCreateComponent },
            { path: 'profile-edit', component: ProfileEditComponent },
            {path: 'news', component: NewsComponent},
            { path: '**', redirectTo: '/public' }    
        ])
    ],
    providers: [
        AppService,
        NewsService,
		AgendaService,
		CampaignService,
		CandidateService,
		ConstituencyService,
		ElectionService,
		EventService,
		ExpenseService,
		MapService,
		NotificationService,
		PoliticalPartyService,
		PollingSchemeService,
		ProfileService,
		ProfileTypeService,
		VoterslistService,
        Configuration,

    ],
    exports: [
    ]
})
export class AppModuleShared {
}
