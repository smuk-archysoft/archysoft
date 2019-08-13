import { Injectable } from '@angular/core';
import { AuthService as AuthenticationService } from 'ngx-auth';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { TokenService } from './token.service';
import { Observable } from 'rxjs';
import { tap, map, switchMap, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { TokenModel } from '../models/token.model';
import { LoginModel } from '../models/login.model';
import { ApiResponse, ApiResponseEmpty } from 'src/app/shared/models/api-response.model';
import { SignupModel } from '../models/signup.model';
import { ConfirmEmailModel } from '../models/confirm-email.model';
import { ForgotPasswordModel } from '../models/forgot-password.model';
import { BaseService } from 'src/app/core/services/base.service';
import { RecoverPasswordModel } from '../models/recover-password.model';

@Injectable()
export class AuthService implements AuthenticationService {

  constructor(
    private http: HttpClient,
    private tokenService: TokenService,
    private baseService: BaseService
  ) { }

  public isAuthorized(): Observable<boolean> {
    return this.tokenService.getAccessToken().pipe(map(token => !!token));
  }

  public getAccessToken(): Observable<string> {
    return this.tokenService.getAccessToken();
  }

  public refreshToken(): Observable<TokenModel> {
    return this.tokenService
      .getRefreshToken()
      .pipe(
        switchMap((refreshToken: string) =>
          this.http.post(`${environment.apiUrl}/auth/refresh`, { refreshToken })
        ),
        tap((tokens: TokenModel) => this.saveAccessData(tokens)),
        catchError((err) => {
          this.logOut();

          return Observable.throw(err);
        })
      );
  }

  public refreshShouldHappen(response: HttpErrorResponse): boolean {
    return response.status === 401;
  }

  public verifyTokenRequest(url: string): boolean {
    return url.endsWith('/refresh');
  }

  public logIn(loginModel: LoginModel): Observable<ApiResponse<TokenModel>> {
    const headers = new HttpHeaders();
    headers.set('Content-Type', 'application/json; charset=utf-8');

    return this.http.post(`${environment.apiUrl}/auth/login`, loginModel, { headers: headers })
      .pipe(tap((response: ApiResponse<TokenModel>) => this.saveAccessData(response.model)));
  }

  public logOut(): void {
    this.tokenService.clear();
    location.reload(true);
  }

  private saveAccessData(tokenModel: TokenModel) {
    if (tokenModel) {
      this.tokenService
        .setAccessToken(tokenModel.accessToken)
        .setRefreshToken(tokenModel.refreshToken);
    }
  }

  signUp(signupModel: SignupModel): Observable<ApiResponse<null>> {
    const headers = new HttpHeaders();
    headers.set('Content-Type', 'application/json; charset=utf-8');

    return this.http.post(`${environment.apiUrl}/auth/signup`, signupModel, { headers: headers })
      .pipe(tap((response: ApiResponse<null>) => this.saveAccessData(response.model)));
  }

  confirmEmail(confirmEmailModel: ConfirmEmailModel): Observable<ApiResponse<null>> {
    const headers = new HttpHeaders();
    headers.set('Content-Type', 'application/json; charset=utf-8');

    return this.http.post(`${environment.apiUrl}/auth/confirm-email`, confirmEmailModel, { headers: headers })
      .pipe(tap((response: ApiResponse<null>) => this.saveAccessData(response.model)));
  }

  forgotPassword(forgotPasswordModel: ForgotPasswordModel): Observable<ApiResponse<any>> {
    const headers = new HttpHeaders();
    headers.set('Content-Type', 'application/json; charset=utf-8');

    return this.http.post(`${environment.apiUrl}/auth/forgot-password`, forgotPasswordModel, { headers: headers })
      .pipe(map((response: ApiResponse<any>) => response));
  }

  public recoverPassword(recoverPasswordModel: RecoverPasswordModel) :Observable<ApiResponseEmpty>{
    const headers = new HttpHeaders();
    headers.set('Content-Type', 'application/json; charset=utf-8');

    return this.http.post(`${environment.apiUrl}/auth/recover-password`, recoverPasswordModel, {headers: headers})
    .pipe(tap((response: ApiResponseEmpty) => {}));
  }
}
