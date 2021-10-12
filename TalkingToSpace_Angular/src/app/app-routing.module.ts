import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { HelpComponent } from './help/help.component';
import { ProfileComponent } from './profile/profile.component';
import { BlogComponent } from './blog/blog.component';
import { TournamentComponent } from './tournament/tournament.component';
import { StartComponent } from './start/start.component';
import {PostComponent} from './post/post.component'
import { AuthGuard } from '@auth0/auth0-angular';

const routes: Routes = [
  { path: 'about', component: AboutComponent, canActivate: [AuthGuard]},
  { path: 'blog', component: BlogComponent, canActivate: [AuthGuard]},
  { path: 'help', component: HelpComponent, canActivate: [AuthGuard]},
  { path: 'home', component: HomeComponent, canActivate: [AuthGuard]},
  { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard]},
  { path: 'tournament', component: TournamentComponent, canActivate: [AuthGuard]},
  { path: 'post', component: PostComponent, canActivate: [AuthGuard]},
  { path: 'start', component: StartComponent},
  { path: '', redirectTo: '/start', pathMatch: 'full' }
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
