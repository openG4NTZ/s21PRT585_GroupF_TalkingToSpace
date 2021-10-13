import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { HelpComponent } from './help/help.component';
import { ProfileComponent } from './profile/profile.component';
import { ForgotComponent } from './login/forgot/forgot.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { BlogComponent } from './blog/blog.component';
import { TournamentComponent } from './tournament/tournament.component';
import { StartComponent } from './start/start.component';

const routes: Routes = [
  { path: 'about', component: AboutComponent},
  { path: 'blog', component: BlogComponent},
  { path: 'help', component: HelpComponent},
  { path: 'home', component: HomeComponent},
  { path: 'login', component: LoginComponent},
  { path: 'login/forgot', component: ForgotComponent},
  { path: 'profile', component: ProfileComponent},
  { path: 'signup', component: SignupComponent},
  { path: 'tournament', component: TournamentComponent},
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
