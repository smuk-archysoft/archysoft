import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { AuthService } from '../../services/auth.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ConfirmEmailModel } from '../../models/confirm-email.model';
import { ApiResponse } from 'src/app/shared/models/api-response.model';
import { timer } from 'rxjs';


@Component({
  selector: 'app-confirm-email',
  templateUrl: './confirm-email.component.html',
  styleUrls: ['./confirm-email.component.scss']
})
export class ConfirmEmailComponent implements OnInit {

  loading = false;
  message: string;
  model: ConfirmEmailModel;

  constructor(
    private translateService: TranslateService,
    private authService: AuthService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.route.queryParams.subscribe(
      (queryParam: ConfirmEmailModel) => {
        this.model = queryParam;
      }
    );
  }

  ngOnInit() {
    this.loading = true;
    this.authService.confirmEmail(this.model).subscribe((response: ApiResponse<null>) => {
      this.loading = false;
      if (response && response.status === 1 && response.message == "Success") {
        this.message = this.translateService.instant('AUTH.CONFIRM_EMAIL_SUCCESS');
      }
      else {
        this.message = this.translateService.instant('AUTH.CONFIRM_EMAIL_FAILURE');
      }
      timer(5000).subscribe(() => this.router.navigate(['/']));
    },
      (error: any) => {
        this.loading = false;
        this.message = this.translateService.instant('AUTH.SERVER_ERROR');
        timer(5000).subscribe(() => this.router.navigate(['/']));
      });
  }



}
