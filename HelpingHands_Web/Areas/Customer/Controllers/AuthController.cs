﻿using Microsoft.AspNetCore.Authentication.Cookies;
                    // ModelState.AddModelError("CustomError", response.ErrorMessages.FirstOrDefault());
                    TempData["error"] = response.ErrorMessages.FirstOrDefault();

                }

        }
                        // ModelState.AddModelError("CustomError", response.ErrorMessages.FirstOrDefault());
                        TempData["error"] = result.ErrorMessages.FirstOrDefault();

                }

            }
            // return RedirectToAction("Index", "Home");
            return RedirectToAction("Index", "Home", new { area = "Customer" });