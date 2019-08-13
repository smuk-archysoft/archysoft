import { Component, OnInit } from '@angular/core';
import { RecoverPasswordModel } from '../../models/recover-password.model';
import { AuthService } from '../../services/auth.service';
import { ApiResponseEmpty } from 'src/app/shared/models/api-response.model';
import { Router, ActivatedRoute } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { AuthNotificationService } from '../../services/auth-notification.service';


@Component({
  selector: 'app-recover-password',
  templateUrl: './recover-password.component.html',
  styleUrls: ['./recover-password.component.scss']
})
export class RecoverPasswordComponent implements OnInit {
  model: RecoverPasswordModel = { password: '', passwordConfirm: '', userId:'', token: ''};
  loading = false;

  constructor(
    private translateService: TranslateService,
    private authService: AuthService,
    private router: Router,
    private activateRoute: ActivatedRoute,
    private authNotificationService: AuthNotificationService
    ) { 
      activateRoute.queryParams.subscribe(
        (queryParam: any) => {
            this.model.token = queryParam['token'];
            this.model.userId = queryParam['id'];
            this.model.password = 'passwordqwerty';
            this.model.passwordConfirm = 'passwordqwerty';
        });
    }

  ngOnInit(): void {

  } 

  recoverPassword(){
    if(this.model.password == this.model.passwordConfirm){
      this.authService.recoverPassword(this.model).subscribe((response: ApiResponseEmpty) => {
        this.loading = false;
        if (response && response.status === 1) {
          this.router.navigate(['']);
        }
        else if(response.status == -2){
          this.authNotificationService.notify(this.translateService.instant('AUTH.NON_AUTORIZE_ERROR'), 'error');
        }
    });
    }
    else{
      this.authNotificationService.notify(this.translateService.instant('AUTH.PASSWORD_CONFIRM_ERROR'), 'error');
    }   
  }

  navigateToLoginForm() {
    this.router.navigate(['/auth/login']);
  }
}
