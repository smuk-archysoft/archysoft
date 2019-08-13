import { Component, OnInit } from '@angular/core';
import { LoginModel } from '../../models/login.model';
import { AuthService } from '../../services/auth.service';
import { ApiResponse } from 'src/app/shared/models/api-response.model';
import { Router } from '@angular/router';
import { AuthNotificationService } from '../../services/auth-notification.service';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  model: LoginModel = { login: 'admin@d1.archysoft.com', password: 'admin', remeberMe: false };

  constructor(
    private authService: AuthService,
    private router: Router,
    private authNotificationService: AuthNotificationService,
    private translateService: TranslateService
  ) { }

  ngOnInit() {
  }

  login() {
    this.authService.logIn(this.model).subscribe((response: ApiResponse<any>) => {
      if (response.status === 1) {
        this.router.navigateByUrl('/');
      }
      else {
        this.authNotificationService.notify(this.translateService.instant('AUTH.INVALID_LOGIN_OR_PASSWORD'), 'error');
      }
    },
      (error: any) => {
      //  this.loading = false;
        this.authNotificationService.notify(this.translateService.instant('AUTH.SERVER_ERROR'), 'error');
      });
  }

  navigateToForgotPasswordForm() {
    this.router.navigate(['/auth/forgot-password'])
  }

  navigateToSignUp() {
    this.router.navigate(['/auth/signup'])
  }

}
