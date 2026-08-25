import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { TranslatePipe } from '@ngx-translate/core';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzDropDownModule } from 'ng-zorro-antd/dropdown';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { Language, LanguageService } from '../../core/services/language';

@Component({
  selector: 'app-header',
  imports: [TranslatePipe, NzLayoutModule, NzIconModule, NzDropDownModule, NzButtonModule],
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './header.html',
  styleUrl: './header.css',
})
export class Header {
  readonly languageService = inject(LanguageService);

  changeLanguage(language: Language): void {
    this.languageService.changeLanguage(language);
  }
}
