import { Component, OnInit } from '@angular/core';
import { NgForm, FormGroup, Validators, FormBuilder } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';
import { AuthService } from '../../services/auth.service';
import { AuthNotificationService } from '../../services/auth-notification.service';
import { Router } from '@angular/router';
import { ApiResponse } from 'src/app/shared/models/api-response.model';
import { SignupModel } from '../../models/signup.model';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {

  model: SignupModel = { 
    email: 'admin@d1.archysoft.com', 
    username: 'Joan', 
    password: '197346RKavbyz', 
    passwordConfirm: '197346RKavbyz' 
  };

  regExp: string | RegExp = "^(?=.*[a-z])(?=.*[A-Z])(?=\d*).{5,}$";
  myForm: FormGroup;
  loading = false;

  constructor(private formBuilder: FormBuilder,
    private translateService: TranslateService,
    private authService: AuthService,
    private authNotificationService: AuthNotificationService,
    private router: Router) { }

  ngOnInit(): void {
    this.myForm = this.formBuilder.group({
      email: ['', Validators.compose([Validators.required, Validators.email])],
      username: ['', Validators.required],
      password: ['', [Validators.required, Validators.pattern(this.regExp)]],
      passwordConfirm: ['', Validators.required]
    }, { validator: this.checkIfMatchingPasswords('password', 'passwordConfirm') });
  }

  checkIfMatchingPasswords(passwordKey: string, passwordConfirmationKey: string) {
    return (group: FormGroup) => {
      let passwordInput = group.controls[passwordKey],
        passwordConfirmationInput = group.controls[passwordConfirmationKey];
      if (passwordInput.value !== passwordConfirmationInput.value) {
        return passwordConfirmationInput.setErrors({ notEquivalent: true })
      }
      else {
        return passwordConfirmationInput.setErrors(null);
      }
    }
  }

  signUp(form: NgForm) {
    this.loading = true;
    this.authService.signUp(this.model).subscribe((response: ApiResponse<null>) => {
      this.loading = false;
      console.log(response);
      if (response && response.status === 1 && response.message == "Success") {
        this.authNotificationService.notify('');
        this.router.navigate(['/']);
      }
      else {
        this.authNotificationService.notify(this.translateService.instant('AUTH.SIGNUP_USER_EXISTS'), 'error');
      }
    },
      (error: any) => {
        this.loading = false;
        this.authNotificationService.notify(this.translateService.instant('AUTH.SERVER_ERROR'), 'error');
      })
  }

  onFileChanged(event) {
    this.model.userImage = event.target.files[0];
  }

  navigateToLoginForm() {
    this.authNotificationService.notify('');
    this.router.navigate(['/auth/login']);
  }
}
