import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthComponent } from './auth.component';
import { LoginComponent } from './components/login/login.component';
import { SignupComponent } from './components/signup/signup.component';
import { ForgotPasswordComponent } from './components/forgot-password/forgot-password.component';
import { RecoverPasswordComponent } from './components/recover-password/recover-password.component';
import { ConfirmEmailComponent } from './components/confirm-email/confirm-email.component';


const routes: Routes = [
  {
    path: '',
    component: AuthComponent,
    children: [
      { path: 'login', component: LoginComponent }
    ]
  },
  {
    path: '',
    component: AuthComponent,
    children: [
      { path: 'signup', component: SignupComponent }
    ]
  },
  {
    path: '',
    component: AuthComponent,
    children: [
      { path: 'forgot-password', component: ForgotPasswordComponent }
    ]
  },
  {
    path: '',
    component: AuthComponent,
    children: [
      { path: 'recover-password', component: RecoverPasswordComponent }
    ]
  },
  {
    path: '',
    component: AuthComponent,
    children: [
      { path: 'confirm-email', component: ConfirmEmailComponent }
    ]
  },
  {
  path: '',
    component: AuthComponent,
    children: [
      { path: '**', component: LoginComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
