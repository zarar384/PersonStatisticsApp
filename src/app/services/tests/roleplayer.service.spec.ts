import { TestBed } from '@angular/core/testing';

import { RoleplayerService } from '../roleplayer.service';

describe('RoleplayerService', () => {
  let service: RoleplayerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RoleplayerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
