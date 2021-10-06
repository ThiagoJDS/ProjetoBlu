/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { TelefoneService } from './telefone.service';

describe('Service: Telefone', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TelefoneService]
    });
  });

  it('should ...', inject([TelefoneService], (service: TelefoneService) => {
    expect(service).toBeTruthy();
  }));
});
