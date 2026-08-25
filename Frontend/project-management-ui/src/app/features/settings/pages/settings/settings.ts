import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { TranslatePipe } from '@ngx-translate/core';
import { NzCardModule } from 'ng-zorro-antd/card';
import { NzRadioModule } from 'ng-zorro-antd/radio';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { Language, LanguageService } from '../../../../core/services/language';

@Component({
  selector: 'app-settings',
  imports: [FormsModule, TranslatePipe, NzCardModule, NzRadioModule, NzIconModule],
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './settings.html',
  styleUrl: './settings.css'
})
export class Settings {
  readonly languageService = inject(LanguageService);

  changeLanguage(language: Language): void {
    this.languageService.changeLanguage(language);
  }
}
